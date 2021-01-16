package com.taml.givenkeyvaluepairswitharray;

import com.taml.BaseFixture;
import com.taml4j.Parser;
import com.taml4j.TamlDocument;
import org.testng.Assert;
import org.testng.annotations.Test;

import java.io.BufferedReader;
import java.io.IOException;

/**
 * @author Luca Taddeo - Lucalas
 */
public class WhenParserReadsDocumentTest extends BaseFixture {
	@Override
	protected String getSampleFilename() {
		return "GivenKeyValuePairsWithArray/sample.taml";
	}

	@Test
	public void ShouldFindTwoKeyPairs() {
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			Assert.assertEquals(doc.getKeyValuePairs().size(), 2);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}
