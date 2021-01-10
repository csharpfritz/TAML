package com.taml4j;

import java.util.ArrayList;
import java.util.List;

/**
 * @author Luca Taddeo - Lucalas
 */
public class TamlDocument {
	/**
	 * The collection of data stored in the document
	 */
	private List<TamlKeyValuePair> keyValuePairs = new ArrayList<>();

	/**
	 * Instructions for the parser that were identified in the document
	 */
	private TamlMap processorDirectives = new TamlMap();

	public void setProcessorDirectives(TamlMap processorDirectives) {
		this.processorDirectives = processorDirectives;
	}

	public List<TamlKeyValuePair> getKeyValuePairs() {
		return keyValuePairs;
	}

	public TamlMap getProcessorDirectives() {
		return processorDirectives;
	}
}
