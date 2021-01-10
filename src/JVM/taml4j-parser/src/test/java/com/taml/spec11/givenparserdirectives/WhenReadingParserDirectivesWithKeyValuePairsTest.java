package com.taml.spec11.givenparserdirectives;

import com.taml.BaseFixture;
import com.taml4j.Parser;
import com.taml4j.TamlDocument;
import com.taml4j.TamlValue;
import org.testng.Assert;
import org.testng.annotations.Test;

import java.io.BufferedReader;
import java.io.IOException;
import java.util.Map;

/**
 * @author Luca Taddeo - Lucalas
 */
public class WhenReadingParserDirectivesWithKeyValuePairsTest extends BaseFixture {
	@Override
	protected String getSampleFilename() {
		return "Spec11/GivenParserDirectives/sample.taml";
	}

	@Test
	public void ThenResultShouldIdentifyDirectiveAndSetting()
	{
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			Assert.assertEquals(doc.getProcessorDirectives().size(), 1);

			Map.Entry<String, TamlValue> directive = doc.getProcessorDirectives().entrySet().iterator().next();
			Assert.assertEquals(directive.getKey(), "TAML.SpecVersion");
			Assert.assertEquals(directive.getValue().toString(), "1.1");
		} catch (IOException e) {
			e.printStackTrace();
		}

	}
}
