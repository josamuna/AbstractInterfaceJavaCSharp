package com.josamuna.projects.connectionsample;

import java.sql.Connection;
import java.sql.SQLException;

public interface IConnection {
	Connection getConnection() throws SQLException;
}
