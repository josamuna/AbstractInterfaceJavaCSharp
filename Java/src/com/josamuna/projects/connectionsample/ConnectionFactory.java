package com.josamuna.projects.connectionsample;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class ConnectionFactory {
	private static Connection connection = null;
	public static final int MYSQL_CONNECTION = 1;
	public static final int SQL_SERVER_CONNECTION = 2;

	private ConnectionFactory() {
	}

	/**
	 * Instantiate a Database (MySQL, SQL Server, etc.) connection string and return
	 * it (Using Singleton Pattern by returning only one instance of the class)
	 * 
	 * @return Connection
	 * @throws SQLException
	 */
	public static Connection getConnection(int connectionType) throws SQLException {
		if (connection == null) {
			switch (connectionType) {
			case MYSQL_CONNECTION:
				connection = createMySQLConnection();
				break;
			case SQL_SERVER_CONNECTION:
				connection = createSQLServerConnection();
				break;
			default:
				throw new SQLException("No Database type specified!");
			}

		}
		return connection;
	}

	private static String formatSQLServerConnectionString(Connect connect) {
		return String.format("jdbc:sqlserver://%s;databaseName=%s;user=%s;password=%s", connect.getHost(),
				connect.getDatabase(), connect.getUsername(), connect.getPassword());
	}

	private static Connection createSQLServerConnection() throws SQLException {
		String strCon = formatSQLServerConnectionString(
				new Connect("DESKTOP-E7LIT2H\\SQLEXPRESS", "db_person", "sa", "password"));
		return DriverManager.getConnection(strCon);
	}

	private static String formatMySQLConnectionString(Connect connect) {
		return String.format("jdbc:mysql://%s:%s/%s?user=%s&password=%s&ServerTimeZone=UTC", connect.getHost(),
				connect.getPort(), connect.getDatabase(), connect.getUsername(), connect.getPassword());
	}

	private static Connection createMySQLConnection() throws SQLException {
		String strCon = formatMySQLConnectionString(new Connect("localhost", 3306, "db_person", "root", ""));
		return DriverManager.getConnection(strCon);
	}

}
