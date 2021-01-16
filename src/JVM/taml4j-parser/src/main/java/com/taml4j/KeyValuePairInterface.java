package com.taml4j;

/**
 * @author Luca Taddeo - Lucalas
 */
public interface KeyValuePairInterface<T, K> {
	void setKey(T key);

	T getKey();

	K getValue();
}
