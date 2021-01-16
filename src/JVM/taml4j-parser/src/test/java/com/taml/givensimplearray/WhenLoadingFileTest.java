package com.taml.givensimplearray;

import com.taml.BaseFixture;
import com.taml4j.Parser;
import com.taml4j.TamlArray;
import com.taml4j.TamlDocument;
import com.taml4j.TamlKeyValuePair;
import org.testng.Assert;
import org.testng.annotations.Test;

import java.io.BufferedReader;
import java.io.IOException;

/**
 * @author Luca Taddeo - Lucalas
 */
public class WhenLoadingFileTest extends BaseFixture {
	@Override
	protected String getSampleFilename() {
		return "GivenSimpleArray/sample.taml";
	}

	@Test
	public void ThenShouldFindAnArray()
	{
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			Assert.assertEquals(doc.getKeyValuePairs().size(), 1);
			Assert.assertTrue(doc.getKeyValuePairs().get(0).getValue() instanceof TamlArray);
		} catch (IOException e) {
			e.printStackTrace();
		}

	}

	@Test
	public void ThenArrayShouldContainThreeElements()
	{
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			TamlKeyValuePair entry = doc.getKeyValuePairs().get(0);
			Assert.assertEquals(entry.getKey(), "key");

			TamlArray array = (TamlArray) entry.getValue();
			Assert.assertEquals(array.count(), 3);
		} catch (IOException e) {
			e.printStackTrace();
		}

	}

	@Test
	public void ThenArrayShouldIgnoreTrailingSpace()
	{
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			TamlKeyValuePair entry =doc.getKeyValuePairs().get(0);
			Assert.assertEquals(entry.getKey(), "key");

			TamlArray array = (TamlArray) entry.getValue();
			Assert.assertEquals(array.get(2).toString(), "value3");
		} catch (IOException e) {
			e.printStackTrace();
		}

	}
}
