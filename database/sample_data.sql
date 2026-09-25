-- Test data for the attendance app
-- Run this after schema.sql on an empty database

USE attendance_registry;

-- Students
INSERT INTO Students (StudentId, FirstName, LastName, Email) VALUES
('S2600101', 'Liam', 'Nguyen', 'liam.nguyen@example.com'),
('S2600102', 'Olivia', 'Smith', 'olivia.smith@example.com'),
('S2600103', 'Noah', 'Patel', 'noah.patel@example.com'),
('S2600104', 'Mia', 'Chen', 'mia.chen@example.com'),
('S2600105', 'Jack', 'Wilson', 'jack.wilson@example.com'),
('S2600106', 'Ava', 'Thapa', '');

-- Classes
INSERT INTO Classes (ClassCode, ClassName, Teacher) VALUES
('ITS203', 'Object-Oriented Design and Programming', 'Dr Sarah Jones'),
('ITS201', 'Database Systems', 'Mr David Lee');

-- save the new class ids so the inserts below can use them
SET @its203 = (SELECT ClassId FROM Classes WHERE ClassCode = 'ITS203');
SET @its201 = (SELECT ClassId FROM Classes WHERE ClassCode = 'ITS201');

-- Enrolments (all 6 students in ITS203, 4 students in ITS201)
INSERT INTO Enrolments (StudentId, ClassId, EnrolledOn) VALUES
('S2600101', @its203, '2026-08-17'),
('S2600102', @its203, '2026-08-17'),
('S2600103', @its203, '2026-08-17'),
('S2600104', @its203, '2026-08-17'),
('S2600105', @its203, '2026-08-17'),
('S2600106', @its203, '2026-08-17'),
('S2600102', @its201, '2026-08-17'),
('S2600104', @its201, '2026-08-17'),
('S2600105', @its201, '2026-08-17'),
('S2600106', @its201, '2026-08-17');

-- ITS203 attendance on Mondays (1 = present, 0 = absent)
-- Noah (60%) and Jack (40%) are below 75%
INSERT INTO Attendance (StudentId, ClassId, AttendanceDate, IsPresent) VALUES
('S2600101', @its203, '2026-08-24', 1),
('S2600102', @its203, '2026-08-24', 1),
('S2600103', @its203, '2026-08-24', 1),
('S2600104', @its203, '2026-08-24', 1),
('S2600105', @its203, '2026-08-24', 0),
('S2600106', @its203, '2026-08-24', 1),

('S2600101', @its203, '2026-08-31', 1),
('S2600102', @its203, '2026-08-31', 0),
('S2600103', @its203, '2026-08-31', 1),
('S2600104', @its203, '2026-08-31', 1),
('S2600105', @its203, '2026-08-31', 1),
('S2600106', @its203, '2026-08-31', 1),

('S2600101', @its203, '2026-09-07', 1),
('S2600102', @its203, '2026-09-07', 1),
('S2600103', @its203, '2026-09-07', 0),
('S2600104', @its203, '2026-09-07', 1),
('S2600105', @its203, '2026-09-07', 0),
('S2600106', @its203, '2026-09-07', 0),

('S2600101', @its203, '2026-09-14', 1),
('S2600102', @its203, '2026-09-14', 1),
('S2600103', @its203, '2026-09-14', 1),
('S2600104', @its203, '2026-09-14', 1),
('S2600105', @its203, '2026-09-14', 1),
('S2600106', @its203, '2026-09-14', 1),

('S2600101', @its203, '2026-09-21', 1),
('S2600102', @its203, '2026-09-21', 1),
('S2600103', @its203, '2026-09-21', 0),
('S2600104', @its203, '2026-09-21', 1),
('S2600105', @its203, '2026-09-21', 0),
('S2600106', @its203, '2026-09-21', 1);

-- ITS201 attendance on Wednesdays
-- Mia (60%) is below 75%
INSERT INTO Attendance (StudentId, ClassId, AttendanceDate, IsPresent) VALUES
('S2600102', @its201, '2026-08-26', 1),
('S2600104', @its201, '2026-08-26', 1),
('S2600105', @its201, '2026-08-26', 1),
('S2600106', @its201, '2026-08-26', 1),

('S2600102', @its201, '2026-09-02', 1),
('S2600104', @its201, '2026-09-02', 0),
('S2600105', @its201, '2026-09-02', 1),
('S2600106', @its201, '2026-09-02', 1),

('S2600102', @its201, '2026-09-09', 1),
('S2600104', @its201, '2026-09-09', 1),
('S2600105', @its201, '2026-09-09', 0),
('S2600106', @its201, '2026-09-09', 1),

('S2600102', @its201, '2026-09-16', 1),
('S2600104', @its201, '2026-09-16', 0),
('S2600105', @its201, '2026-09-16', 1),
('S2600106', @its201, '2026-09-16', 1),

('S2600102', @its201, '2026-09-23', 1),
('S2600104', @its201, '2026-09-23', 1),
('S2600105', @its201, '2026-09-23', 1),
('S2600106', @its201, '2026-09-23', 1);
