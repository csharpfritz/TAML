package com.taml.givencomplexchilddocument;

import com.taml.BaseFixture;
import com.taml4j.Parser;
import com.taml4j.TamlArray;
import com.taml4j.TamlDocument;
import com.taml4j.TamlKeyValuePair;
import org.testng.Assert;
import org.testng.annotations.BeforeMethod;
import org.testng.annotations.Test;

import java.io.BufferedReader;
import java.io.IOException;

/**
 * @author Luca Taddeo - Lucalas
 */
public class WhenParsingSampleOneTest extends BaseFixture {
	@Override
	protected String getSampleFilename() {
		return "GivenComplexChildDocument/sample1.taml";
	}

	@Test
	public void ShouldHaveOneRootKey() {
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);

			Assert.assertEquals(doc.getKeyValuePairs().size(), 1);
			Assert.assertEquals(doc.getKeyValuePairs().get(0).getKey(), "root");
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Test
	public void ShouldHaveThreeElementsInTheTopArray() {
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			Assert.assertEquals(((TamlArray)doc.getKeyValuePairs().get(0).getValue()).count(), 3);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Test
	public void ShouldHaveCorrectValueTypesInTheTopArray() {
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);

			TamlArray rootValue = ((TamlArray)doc.getKeyValuePairs().get(0).getValue());
			Assert.assertTrue(rootValue.get(0) instanceof TamlKeyValuePair);
			Assert.assertTrue(rootValue.get(1) instanceof TamlKeyValuePair);
			Assert.assertTrue(rootValue.get(2) instanceof TamlKeyValuePair);
			Assert.assertTrue(((TamlKeyValuePair)rootValue.get(2)).getValue() instanceof TamlArray);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
