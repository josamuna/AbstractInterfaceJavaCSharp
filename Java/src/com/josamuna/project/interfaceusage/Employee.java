package com.josamuna.project.interfaceusage;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.josamuna.projects.connectionsample.ConnectionFactory;

public class Employee implements IPerson {
	private int id;
	private String firstName;
	private String lastName;
	private String cnss;

	public Employee() {
	}

	public Employee(int id, String firstName, String lastName, String cnss) {
		this.id = id;
		this.firstName = firstName;
		this.lastName = lastName;
		this.cnss = cnss;
	}

	public int getId() {
		return id;
	}

	public void setId(int id) {
		this.id = id;
	}

	public String getFirstName() {
		return firstName;
	}

	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}

	public String getLastName() {
		return lastName;
	}

	public void setLastName(String lastName) {
		this.lastName = lastName;
	}

	public String getCnss() {
		return cnss;
	}

	public void setCnss(String cnss) {
		this.cnss = cnss;
	}

	@Override
	public void showIdentity() {
		System.out.println(String.format("Employee with ID [%s], FirstName [%s], LastName [%s], Social Security [%s]",
				id, firstName, lastName, cnss));
	}

	@Override
	public void showDynamicIdentity(int id) throws SQLException {
		String sqlQuery = "Select employee.id, employee.firstname, employee.lastname, employee.cnss FROM employee WHERE employee.id=?";
		// Usage of try-with-resources statement to unsure that JDBC resources are
		// properly closed
		try (PreparedStatement ps = ConnectionFactory.getConnection(ConnectionFactory.MYSQL_CONNECTION)
				.prepareStatement(sqlQuery)) {
			ps.setInt(1, id);

			try (ResultSet rs = ps.executeQuery()) {
				if (rs.next()) {
					System.out.println(
							String.format("Employee with ID [%s], FirstName [%s], LastName [%s], Social Security [%s]",
									rs.getInt("id"), rs.getString("firstname"), rs.getString("lastname"),
									rs.getString("cnss")));
				}
			}
		}
	}

	@Override
	public int add() throws SQLException {
		String sqlQuery = "INSERT INTO employee(id,firstName,lastName,cnss) VALUES(?,?,?,?)";
		try (PreparedStatement ps = ConnectionFactory.getConnection(ConnectionFactory.MYSQL_CONNECTION)
				.prepareStatement(sqlQuery)) {
			ps.setInt(1, id);
			ps.setString(2, firstName);
			ps.setString(3, lastName);
			ps.setString(4, cnss);

			return ps.executeUpdate();
		}
	}

}
