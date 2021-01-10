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
public class WhenReadingSingleTermParserDirectivesTest extends BaseFixture {
	@Override
	protected String getSampleFilename() {
		return "Spec11/GivenParserDirectives/singleTerm.taml";
	}

	@Test
	public void ThenResultShouldIdentifyDirectiveAndSetting()
	{
		try (BufferedReader r = getReader()) {
			TamlDocument doc = Parser.Parse(r);
			Assert.assertEquals(doc.getProcessorDirectives().size(), 1);

			Map.Entry<String, TamlValue> directive = doc.getProcessorDirectives().entrySet().iterator().next();
			Assert.assertEquals(directive.getKey(), "TAML.Strict");
		} catch (IOException e) {
			e.printStackTrace();
		}

	}
}
