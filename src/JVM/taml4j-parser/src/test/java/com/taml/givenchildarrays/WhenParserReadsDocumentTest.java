package com.taml.givenchildarrays;

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
public class WhenParserReadsDocumentTest extends BaseFixture {
	@Override
	protected String getSampleFilename() {
		return "GivenChildArrays/childarrays.taml";
	}

	@Test
	public void ShouldFindThreeElements() {

		try (BufferedReader r = getReader()) {
			TamlDocument result = Parser.Parse(r);

			Assert.assertTrue((result.getKeyValuePairs().get(0).getValue() instanceof TamlArray));
			Assert.assertEquals(3, (((TamlArray)result.getKeyValuePairs().get(0).getValue()).count()));
			Assert.assertEquals(3, result.getKeyValuePairs().size());

			TamlKeyValuePair thisPair = result.getKeyValuePairs().get(0);
			Assert.assertEquals(thisPair.getKey(), "value1");
			Assert.assertEquals(((TamlArray)(thisPair.getValue())).get(0).toString(), "value12");
			Assert.assertEquals(((TamlArray)(thisPair.getValue())).get(1).toString(), "value13");
			Assert.assertEquals(((TamlArray)(thisPair.getValue())).get(2).toString(), "value14");

			thisPair = result.getKeyValuePairs().get(1);
			Assert.assertEquals(thisPair.getKey(), "value2");
			Assert.assertEquals(((TamlArray)(thisPair.getValue())).get(0).toString(), "value22");
			Assert.assertEquals(((TamlArray)(thisPair.getValue())).get(1).toString(), "value23");
			Assert.assertEquals(((TamlArray)(thisPair.getValue())).get(2).toString(), "value24");

			thisPair = result.getKeyValuePairs().get(2);
			Assert.assertEquals(thisPair.getKey(), "value3");
			Assert.assertEquals(((TamlArray)(thisPair.getValue())).get(0).toString(), "value32");
			Assert.assertEquals(((TamlArray)(thisPair.getValue())).get(1).toString(), "value33");
			Assert.assertEquals(((TamlArray)(thisPair.getValue())).get(2).toString(), "value34");
		} catch (IOException e) {
			e.printStackTrace();
		}

	}
}
