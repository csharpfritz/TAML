package com.taml4j;

/**
 * @author Luca Taddeo - Lucalas
 */
public class TamlKeyValuePair extends TamlValue implements KeyValuePairInterface<String, TamlValue>  {

	protected String key;
	protected TamlValue value;

	public TamlKeyValuePair(String key, TamlValue value) {
		this.key = key;
		this.value = value;
	}

	public void setKey(String key) {
		this.key = key;
	}

	public String getKey() {
		return key;
	}

	public TamlValue getValue() {
		return value;
	}

	public TamlValue setValue(TamlValue value) {
		this.value = value;
		return value;
	}

	public boolean hasValue() {
		return value != null;
	}

	@Override
	public String toString() {
		return hasValue() ? key + ": " + value : key;
	}

}
