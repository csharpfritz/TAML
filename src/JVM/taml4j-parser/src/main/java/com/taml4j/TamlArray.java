package com.taml4j;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Luca Taddeo - Lucalas
 */
public class TamlArray extends TamlValue {
	List<TamlValue> values = new ArrayList<>();

	public void appendValue(TamlValue newValue)
	{
		values.add(newValue);
	}

	public int count() {
		return values.size();
	}

	public TamlValue get(int pos) {
		return values.get(pos);
	}

	public List<TamlValue> getValues() {
		return values;
	}
}
