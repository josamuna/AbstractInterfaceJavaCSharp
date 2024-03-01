package com.josamuna.project.interfaceusage;

import java.sql.Connection;
import java.sql.SQLException;

import com.josamuna.project.interfaceusage.Employee;
import com.josamuna.project.interfaceusage.IPerson;
import com.josamuna.project.interfaceusage.Student;
import com.josamuna.projects.connectionsample.ConnectionFactory;

public class TestInterface {

	public static void main(String[] args) {
		try {
			IPerson e3 = new Employee();
			((Employee) e3).setId(3);
			((Employee) e3).setFirstName("Rebecca");
			((Employee) e3).setLastName("Kabene");
			((Employee) e3).setCnss("6738RBHJ989363");

			// insert Employee 3 into the database
			e3.add();
			System.out.println("Employee inserted successfully!");

			IPerson e4 = new Employee();
			((Employee) e4).setId(4);
			((Employee) e4).setFirstName("Sage");
			((Employee) e4).setLastName("Alingisugho");
			((Employee) e4).setCnss("512389ASGYIUE9374");

			// Insert Employee 4 into the Database
			e4.add();
			System.out.println("Employee inserted successfully!");

			// Students Insertion
			IPerson s3 = new Student(3, "Esther", "Namegabe", "521984ESGTH8476");
			s3.add();
			System.out.println("Student inserted successfully!");

			IPerson s4 = new Student(4, "Gloria", "Kavira", "9825367GKQG7520983");
			s4.add();

			System.out.println("Student insert successfully!");
			// Show inserted values for Employee
//			e3.showIdentity();
			e3.showDynamicIdentity(((Employee) e3).getId());
			System.out.println("-----------------------------------------");
//			e4.showIdentity();
			e4.showDynamicIdentity(((Employee) e4).getId());
			System.out.println("-----------------------------------------");

			// Show inserted values for Student
			s3.showDynamicIdentity(((Student) s3).getId());
			System.out.println("------------------------------------------");
			s4.showDynamicIdentity(((Student) s4).getId());
			System.out.println("-----------------------------------------");
		} catch (SQLException e) {
			System.out.println("Failed to insert records to the Database");
			e.printStackTrace();
		} finally {
			try {
				// Properly close connection to the DataBase even if error occurs, by using
				// try-with-resources
				try (Connection connection = ConnectionFactory.getConnection(ConnectionFactory.MYSQL_CONNECTION)) {
				}
			} catch (Exception e2) {
				System.out.println(e2.getMessage());
				e2.printStackTrace();
			}
		}

	}

}
