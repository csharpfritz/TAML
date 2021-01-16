package com.taml.givencomplexchilddocument;

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
public class WhenParsingSampleTwoTest extends BaseFixture {
	@Override
	protected String getSampleFilename() {
		return "GivenComplexChildDocument/sample2.taml";
	}

	@Test
	public void ShouldHaveTwoRootKeys() {
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);

			Assert.assertEquals(doc.getKeyValuePairs().size(), 2);
			Assert.assertEquals(doc.getKeyValuePairs().get(0).getKey(), "root1");
			Assert.assertEquals(doc.getKeyValuePairs().get(doc.getKeyValuePairs().size() - 1).getKey(), "root2");
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Test
	public void ShouldHaveFourElementsInTheTopArray() {
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			Assert.assertEquals(((TamlArray) doc.getKeyValuePairs().get(0).getValue()).count(), 4);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Test
	public void ShouldHaveFourElementsInTheSecondArray() {
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			Assert.assertEquals(((TamlArray) doc.getKeyValuePairs().get(doc.getKeyValuePairs().size() - 1).getValue()).count(), 4);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Test
	public void ShouldHaveCorrectValueTypesInFirstArray() {
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			TamlArray rootValue = (TamlArray)(doc.getKeyValuePairs().get(0).getValue());
			Assert.assertTrue(rootValue.get(0) instanceof TamlKeyValuePair);
			Assert.assertTrue(rootValue.get(1) instanceof TamlKeyValuePair);
			Assert.assertTrue(rootValue.get(2) instanceof TamlKeyValuePair);

			Assert.assertTrue(((TamlKeyValuePair)(rootValue.get(2))).getValue() instanceof TamlArray);
			Assert.assertTrue((rootValue.get(3)) instanceof TamlKeyValuePair);
			Assert.assertEquals(rootValue.get(3).toString(), "key4: value4");
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
