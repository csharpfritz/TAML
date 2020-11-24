import * as mocha from 'mocha';
import * as chai from 'chai';

import { Parser } from './parser';
import { TamlDocument } from './TamlDocument';

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

});
