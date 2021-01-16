package com.taml.spec11.givenparserdirectives;

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
public class WhenReadingParserDirectivesTest extends BaseFixture {
	@Override
	protected String getSampleFilename() {
		return "Spec11/GivenParserDirectives/sample.taml";
	}

	@Test
	public void ThenResultShouldNotConvertToAValue()
	{
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			// assert
			Assert.assertEquals(doc.getKeyValuePairs().size(), 2);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

}
