package com.taml4j;

/**
 * @author Luca Taddeo - Lucalas
 */
public class TamlValue {
	protected final String _value;

	public TamlValue() {
		this("");
	}

	public TamlValue(String value) {
		this._value = value;
	}

	@Override
	public String toString() {
		return _value;
	}


}
