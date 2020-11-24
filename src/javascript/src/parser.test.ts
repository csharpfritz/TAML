import * as mocha from 'mocha';
import * as chai from 'chai';

import { Parser } from './parser';
import { TamlDocument } from './TamlDocument';
import { TamlArray } from './TamlArray';

const expect = chai.expect;
describe('Parser', () => {

  it('should return a TamlDocument' , () => {
    expect(Parser.Parse("")).deep.equal(new TamlDocument());
	});
	
	const onlyKeyValuePairs = `key1	value1
key2	value2`;
	it('should find two keyvaluepairs for the simplest document', () => {
		var outDoc = Parser.Parse(onlyKeyValuePairs);
		expect(outDoc.KeyValuePairs.length).is.equal(2, "Did not find 2 KeyValuePairs");
	});

	const extraTabs = `key1			value1						`;
	it('should strip off extra tabs from the end of a value', () => {
		var kvp = Parser.Parse(extraTabs).KeyValuePairs[0];
		expect(kvp.Value).is.equal("value1");
	});

	const simpleArray = `key
value1
value2
value3						`
it('should detect and return a simple array', () => {
	const kvp = Parser.Parse(simpleArray).KeyValuePairs[0];
	expect(kvp.hasValue).is.true;
	const arr = kvp.Value as TamlArray;
	expect(arr).is.not.null;
	expect(arr.length).is.equal(3);
	expect(arr[0].toString()).is.equal("value1");
	expect(arr[1].toString()).is.equal("value2");
	expect(arr[2].toString()).is.equal("value3");
});

	// Spec 1.1 features

// 	const commentsInDoc = `key1			value1
// # This is a comment					comments are to be ignored
// key2			value2`
// 	it('should ignore lines that start with #', () => {
// 		var outDoc = Parser.Parse(commentsInDoc); 
// 		expect(outDoc.KeyValuePairs.length).is.equal(2, "Parsed and did something with the comment");
// 	});

});
