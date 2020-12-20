package com.taml4j;

/**
 * @author Luca Taddeo - Lucalas
 */
public class KeyValuePair<T, K> implements KeyValuePairInterface<T, K> {
	protected T key;
	protected K value;

	public KeyValuePair(T key, K value) {
		this.key = key;
		this.value = value;
	}

	public void setKey(T key) {
		this.key = key;
	}

	public T getKey() {
		return key;
	}

	public K getValue() {
		return value;
	}

	public K setValue(K value) {
		this.value = value;
		return value;
	}
}
