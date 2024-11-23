--Database Creation
create database ProjectManagement

--Navigate to ProjectManage
use ProjectManage

--Schema Design
--Project table creation
CREATE TABLE Project (
    id INT  PRIMARY KEY identity,
    ProjectName VARCHAR(255) NOT NULL,
    [Description] VARCHAR(MAX),
    [Start_date] DATE,
    [Status] VARCHAR(20)  NOT NULL
)

--Employee table creation
CREATE TABLE Employee (
    id INT PRIMARY KEY,
    name NVARCHAR(255) NOT NULL,
    Designation NVARCHAR(100),
    Gender NVARCHAR(20),
    Salary DECIMAL(10, 2),
    Project_id INT,
	FOREIGN KEY (Project_id) REFERENCES Project(id)
)

--Task table creation
CREATE TABLE Task (
    task_id INT PRIMARY KEY identity,
    task_name NVARCHAR(255) NOT NULL,
    project_id INT,
    employee_id INT,
    Status NVARCHAR(20) CHECK (Status IN ('Assigned', 'Started', 'Completed')) NOT NULL,
    FOREIGN KEY (project_id) REFERENCES Project(id),
    FOREIGN KEY (employee_id) REFERENCES Employee(id)
)

-- Insert records into Project table
INSERT INTO Project ( ProjectName, [Description], [Start_date], [Status])
VALUES 
('Website Redesign', 'Redesigning the company website for better user experience', '2024-01-15', 'In Progress'),
('Mobile App Development', 'Developing a cross-platform mobile application', '2024-02-01', 'Not Started'),
('Data Migration', 'Migrating legacy data to the cloud', '2024-03-10', 'Completed'),
('AI Research', 'Exploring AI models for predictive analytics', '2024-04-20', 'In Progress'),
('Marketing Campaign', 'Launching a digital marketing campaign', '2024-05-01', 'Not Started');

-- Insert records into Employee table
INSERT INTO Employee (id, name, Designation, Gender, Salary, Project_id)
VALUES
(1, 'John Doe', 'Software Developer', 'Male', 60000.00, 1),
(2, 'Jane Smith', 'Project Manager', 'Female', 80000.00, 2),
(3, 'Alice Brown', 'Data Scientist', 'Female', 75000.00, 4),
(4, 'Robert Johnson', 'Marketing Specialist', 'Male', 50000.00, 5),
(5, 'Emily Davis', 'UI/UX Designer', 'Female', 65000.00, 1);

-- Insert records into Task table
INSERT INTO Task (task_name, project_id, employee_id, Status)
VALUES
('Create Wireframes', 1, 5, 'Completed'),
('Develop Backend', 1, 1, 'Started'),
('Design Marketing Plan', 5, 4, 'Assigned'),
('Build AI Model', 4, 3, 'Started'),
('Setup Cloud Infrastructure', 3, NULL, 'Completed'); 

Exec sp_rename 'Employee.project_id',ProjectId
Exec sp_rename 'Project.start_date',StartDate

SELECT 
    name AS ConstraintName,
    OBJECT_NAME(parent_object_id) AS TableName,
    definition AS ConstraintDefinition
FROM 
    sys.check_constraints
WHERE 
    parent_object_id = OBJECT_ID('dbo.Task') AND name = 'CK__Task__Status__3C69FB99';

ALTER TABLE dbo.Task DROP CONSTRAINT CK__Task__Status__3C69FB99;

Exec sp_rename Task