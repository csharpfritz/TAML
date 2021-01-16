package com.taml4j;

import java.util.Map;

/**
 * @author Luca Taddeo - Lucalas
 */
public class ParsedDocument {

	public Map<Integer, KeyValuePair<Integer, TamlKeyValuePair>> lines;

	public TamlMap processorDirectives;

	public ParsedDocument(Map<Integer, KeyValuePair<Integer, TamlKeyValuePair>> lines, TamlMap processorDirectives)
	{
		this.lines = lines;
		this.processorDirectives = processorDirectives;
	}

	public Map<Integer, KeyValuePair<Integer, TamlKeyValuePair>> getLines() {
		return lines;
	}

	public TamlMap getProcessorDirectives() {
		return processorDirectives;
	}
}
