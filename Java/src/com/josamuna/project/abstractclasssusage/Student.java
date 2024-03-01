package com.josamuna.project.abstractclasssusage;

import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;

import com.josamuna.projects.connectionsample.ConnectionFactory;

public class Student extends Person {
	private String rollNumber;

	public Student() {
	}

	public Student(int id, String firstName, String lastName, String rollNumber) {
		super(id, firstName, lastName);
		this.rollNumber = rollNumber;
	}

	public String getRollNumber() {
		return rollNumber;
	}

	public void setRollNumber(String rollNumber) {
		this.rollNumber = rollNumber;
	}

	@Override
	public void showIdentity() {
		System.out.println(String.format("Student with ID [%s], FistName [%s], LastName [%s], Roll Number [%s]", id,
				firstName, lastName, rollNumber));
	}

	@Override
	public int add(Person p) throws SQLException {
		String sqlQuery = "INSERT INTO student(id,firstName,lastName,rollNumber) VALUES(?,?,?,?)";
		// Usage of try-with-resources statement to unsure that JDBC resources are
		// properly closed
		try (PreparedStatement ps = ConnectionFactory.getConnection(ConnectionFactory.MYSQL_CONNECTION)
				.prepareStatement(sqlQuery)) {
			ps.setInt(1, p.getId());
			ps.setString(2, p.getFirstName());
			ps.setString(3, p.getLastName());
			ps.setString(4, ((Student) p).getRollNumber());

			return ps.executeUpdate();
		}
	}

	@Override
	public void showDynamicIdentity(int id) throws SQLException {
		String sqlQuery = "SELECT student.id, student.firstName, student.lastName, student.rollNumber FROM student WHERE student.id=?";
		// Usage of try-with-resources statement to unsure that JDBC resources are
		// properly closed
		try (PreparedStatement ps = ConnectionFactory.getConnection(ConnectionFactory.MYSQL_CONNECTION)
				.prepareStatement(sqlQuery)) {
			ps.setInt(1, id);
			
			try (ResultSet rs = ps.executeQuery()) {
				if (rs.next()) {
					System.out.println(String.format(
							"Student with ID [%s], FistName [%s], LastName [%s], Roll Number [%s]", rs.getInt("id"),
							rs.getString("firstName"), rs.getString("lastName"), rs.getString("rollNumber")));
				}
			}

		}
	}

}
