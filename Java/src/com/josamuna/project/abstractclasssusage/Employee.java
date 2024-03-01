package com.josamuna.project.abstractclasssusage;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.josamuna.projects.connectionsample.ConnectionFactory;

public class Employee extends Person {
	private String cnss;

	public Employee() {
	}

	public Employee(int id, String firstName, String lastName, String cnss) {
		super(id, firstName, lastName);
		this.cnss = cnss;
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
	public int add(Person p) throws SQLException {
		String sqlQuery = "INSERT INTO employee(id,firstName,lastName,cnss) VALUES(?,?,?,?)";
		// Usage of try-with-resources statement to unsure that JDBC resources are
		// properly closed
		try (PreparedStatement ps = ConnectionFactory.getConnection(ConnectionFactory.MYSQL_CONNECTION)
				.prepareStatement(sqlQuery)) {
			ps.setInt(1, p.getId());
			ps.setString(2, p.getFirstName());
			ps.setString(3, p.getLastName());
			ps.setString(4, ((Employee) p).getCnss());

			return ps.executeUpdate();
		}
	}

	@Override
	public void showDynamicIdentity(int id) throws SQLException {
		String sqlQuery = "SELECT employee.id, employee.firstname, employee.lastname, employee.cnss FROM employee WHERE employee.id=?";
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

}
