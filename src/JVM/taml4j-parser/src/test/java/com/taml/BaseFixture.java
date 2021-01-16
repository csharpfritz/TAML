package com.taml;

import java.io.*;
import java.net.URL;

/**
 * @author Luca Taddeo - Lucalas
 */
public abstract class BaseFixture {
	protected BufferedReader getReader() {
		URL url = Thread.currentThread().getContextClassLoader().getResource(getSampleFilename());
		try {
			return new BufferedReader(new InputStreamReader(url.openStream()));
		} catch (IOException e) {
			e.printStackTrace();
		}
		return null;
	}

	protected abstract String getSampleFilename();
}
