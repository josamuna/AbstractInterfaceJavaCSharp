package com.josamuna.project.interfaceusage;

import java.sql.SQLException;

public interface IPerson {
	void showIdentity();
	void showDynamicIdentity(int id) throws SQLException;
	int add() throws SQLException;
}
