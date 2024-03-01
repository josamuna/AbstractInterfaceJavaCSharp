package com.josamuna.project.abstractclasssusage;

import java.sql.Connection;
import java.sql.SQLException;

import com.josamuna.projects.connectionsample.ConnectionFactory;

public class TestAbstract {

	public static void main(String[] args) {
		try {
			Person e1 = new Employee();
			e1.setId(1);
			e1.setFirstName("Josue");
			e1.setLastName("Isamuna");
			((Employee)e1).setCnss("12IJ784GSD890");
			
			// insert Employee 1 into the database
			e1.add(e1);
			System.out.println("Employee inserted successfully!");
			
			Person e2 = new Employee();
			e2.setId(2);
			e2.setFirstName("Nathan");
			e2.setLastName("Kibambe");
			((Employee)e2).setCnss("5239NBK874902");
			
			// Insert Employee 2 into the Database
			e2.add(e2);
			System.out.println("Employee inserted successfully!");
			
			// Students Insertion
			Person s1 = new Student(1, "Martin", "Shabani", "54546MTCFE514");
			s1.add(s1);
			System.out.println("Student inserted successfully!");
			
			Person s2 = new Student(2, "Tresor", "Ndeze", "83843765TSREGF");
			s2.add(s2);
			
			System.out.println("Student insert successfully!");
			// Show inserted values for Employee
//			e1.showIdentity();
			e1.showDynamicIdentity(e1.getId());
			System.out.println("-----------------------------------------");
//			e2.showIdentity();
			e2.showDynamicIdentity(e2.getId());
			System.out.println("-----------------------------------------");
			
			// Show inserted values for Student
			s1.showDynamicIdentity(s1.getId());
			System.out.println("------------------------------------------");
			s2.showDynamicIdentity(s2.getId());
			System.out.println("-----------------------------------------");
		} catch (SQLException e) {
			System.out.println("Failed to insert records to the Database");
			e.printStackTrace();
		} finally {
			try {
				//Properly close connection to the DataBase even if error occurs, by using try-with-resources
				try(Connection connection = ConnectionFactory.getConnection(ConnectionFactory.MYSQL_CONNECTION)){}
			} catch (Exception e2) {
				System.out.println(e2.getMessage());
				e2.printStackTrace();
			}
		}
		
//		Person e1 = new Employee(1, "Josue", "Isamuna", "12IJ784GSD890");
//		e1.showIdentity();
//		
//		Person e2 = new Employee(2, "Kavira", "Kataliko", "KV12537490598GH");
//		e2.showIdentity();
//		
//		Person e3 = new Employee();
//		e3.setId(3);
//		e3.setFirstName("Nathan");
//		e3.setLastName("Kibambe");
//		((Employee)e3).setCnss("5239NBK874902");
//		
//		e3.showIdentity();
	}

}
