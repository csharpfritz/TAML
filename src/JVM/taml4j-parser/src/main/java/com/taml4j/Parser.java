package com.taml4j;

import java.io.*;
import java.util.*;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * @author Luca Taddeo - Lucalas
 */
public class Parser {
	private static final Pattern keyValuePair = Pattern.compile("(?<key>\\S[^\\t]*)\\t+(?<value>\\S[^\\t]*)", Pattern.MULTILINE);
	private static final Pattern singleValue = Pattern.compile("^\t*\\S[^\t]*\t*$");


	public static TamlDocument Parse(BufferedReader reader) {
		ParsedDocument parsedDoc = ReadLines(reader);
		Map<Integer, KeyValuePair<Integer, TamlKeyValuePair>> lines = parsedDoc.getLines();

		TamlDocument document = new TamlDocument();
		document.setProcessorDirectives(parsedDoc.getProcessorDirectives());

		int currentLevel = 0;

		Stack<TamlKeyValuePair> stack = new Stack<>();

		int i = 0;
		Integer lastLineKey = null;
		for (Map.Entry<Integer, KeyValuePair<Integer, TamlKeyValuePair>> line : lines.entrySet()) {

			int indent = line.getValue().getKey();
			TamlKeyValuePair currentPair = line.getValue().getValue();
			if (indent == 0)
			{
				// line is root element
				document.getKeyValuePairs().add(currentPair);
				currentLevel = 0;
				lastLineKey = line.getKey();
				continue;
			}

			if (indent > currentLevel)
			{
				stack.push(lines.get(lastLineKey).getValue());
			}
			else if (indent < currentLevel)
			{
				stack.pop();
			}

			TamlKeyValuePair parent = !stack.empty() ? stack.peek() : null;

			if (indent > currentLevel)
			{
				if (parent != null && parent.getValue() == null)
				{
					TamlArray newArray = new TamlArray();
					newArray.appendValue(currentPair);
					parent.setValue(newArray);
				}
			}
			else if (parent != null && parent.getValue() instanceof TamlArray)
			{
				((TamlArray)parent.getValue()).appendValue(currentPair);
			}
			lastLineKey = line.getKey();
			currentLevel = indent;
		}
		return document;
	}

	private static ParsedDocument ReadLines(BufferedReader reader)
	{
		TamlMap directives = new TamlMap();
		Map lines = new HashMap<Integer, KeyValuePair<Integer, TamlKeyValuePair>>();
		int currentLineNumber = 0;
		try {
			String rawLine;
				while ((rawLine = reader.readLine()) != null) {

					// Handle comments - ignore and read next line
					if (rawLine.charAt(0) == '#') continue;

					int indent = CountIntendedTabs(rawLine);
					String line = rawLine.trim();
					TamlKeyValuePair value;

					if (line == null || line.isEmpty())
					{
						// empty line we ignore
						currentLineNumber--; // we don't count empty lines
						continue;
					}
					else if (line != null && line.contains("\t"))
					{
						// this is a KeyValuePair
						Matcher match = keyValuePair.matcher(line);
						match.find();
						value = new TamlKeyValuePair(match.group("key"), new TamlValue(match.group("value")));
					}
					else
					{
						// this is a single value
						value = new TamlKeyValuePair(line, null);
					}

					if (rawLine.charAt(0) == '!') // This is a processor directive
					{
						value.setKey(value.getKey().replaceAll("^*[ !]", ""));
						directives.put(value.getKey(), value.getValue());
					}
				else
					{
						lines.put(currentLineNumber, new KeyValuePair<>(indent, value));
						currentLineNumber++;
					}
				}
		} catch (IOException e) {
			e.printStackTrace();
		}

		return new ParsedDocument(lines, directives);

	}

	private static int CountIntendedTabs(String currentLine)
	{
		int tabs = 0;
		while (currentLine.charAt(tabs) == '\t')
		{
			tabs++;
		}
		return tabs;
	}
}
