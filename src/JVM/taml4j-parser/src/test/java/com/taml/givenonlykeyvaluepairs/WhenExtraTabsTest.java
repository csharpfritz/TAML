package com.taml.givenonlykeyvaluepairs;

import com.taml.BaseFixture;
import com.taml4j.Parser;
import com.taml4j.TamlDocument;
import org.testng.Assert;
import org.testng.annotations.Test;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.StringReader;

/**
 * @author Luca Taddeo - Lucalas
 */
public class WhenExtraTabsTest extends BaseFixture {
	@Override
	protected String getSampleFilename() {
		return null;
	}

	@Test
	public void ShouldIgnoreTrailingTabs()
	{

		// arrange
		String theDoc = "key	value						";
		try (BufferedReader r = new BufferedReader((new StringReader(theDoc)))) {
			TamlDocument result = Parser.Parse(r);
			// assert
			Assert.assertEquals(result.getKeyValuePairs().get(0).getValue().toString(), "value");
		} catch (IOException e) {
			e.printStackTrace();
		}
	}

	@Test
	public void ShouldIgnoreMultipleInteriorTabs()
	{

		// arrange
		String theDoc = "key										value";
		try (BufferedReader r = new BufferedReader((new StringReader(theDoc)))) {
			TamlDocument result = Parser.Parse(r);

			// assert
			Assert.assertNotNull(result.getKeyValuePairs());
			Assert.assertFalse(result.getKeyValuePairs().isEmpty());
			Assert.assertEquals(result.getKeyValuePairs().get(0).getValue().toString(), "value");
		} catch (IOException e) {
			e.printStackTrace();
		}

	}
}
