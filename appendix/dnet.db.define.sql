
-- User Table
DROP TABLE IF EXISTS `fc_user`;
CREATE TABLE `fc_user` (
    id bigint primary key auto_increment,
    type enum('ST', 'TC') not null,
    username varchar(50) not null,
    password varchar(50) not null,
    alias varchar(50) not null,
    email varchar(50),
    -- Status: New, norMal, Forbidden
    status enum('N', 'M', 'F') not null, 

    UNIQUE INDEX `idx_username_unique` (`username` ASC)
) engine=MyISAM;

-- Admin Table
DROP TABLE IF EXISTS `fc_admin`;
CREATE TABLE fc_admin (
    id bigint primary key auto_increment,
    username varchar(50) not null,
    password varchar(50) not null,
    -- Status: norMal, Forbidden
    status enum('M', 'F') not null, 

    UNIQUE INDEX `idx_username_unique` (`username` ASC)
) engine=MyISAM;

-- Course Table
DROP TABLE IF EXISTS `fc_course`;
CREATE TABLE fc_course (
    id bigint primary key auto_increment,
    name varchar(255) not null,
    description varchar(255),
    weight_speak tinyint,
    weight_report tinyint,
    weight_ask tinyint,
    grouping_regulation_id bigint,
    -- Status: norMal, Forbidden
    status enum('M', 'F') not null
) engine=MyISAM;

-- Grouping Regulation Table
DROP TABLE IF EXISTS `fc_grouping_reg`;
CREATE TABLE fc_grouping_reg (
    id bigint primary key auto_increment,
    members_ceil_num int not null,
    members_floor_num int not null,
    group_start_time bigint not null,
    group_end_time bigint not null
) engine=MyISAM;

-- Grouping Regulation Conflict Course Table
DROP TABLE IF EXISTS `fc_grouping_reg_conflict_course`;
CREATE TABLE fc_grouping_reg_conflict_course (
    reg_id bigint,
    conflict_course_id bigint,
    primary key (reg_id, conflict_course_id),
    foreign key(reg_id) references `fc_grouping_reg`(id),
    foreign key(conflict_course_id) references `fc_course`(id)
) engine=MyISAM;

-- Group Table
DROP TABLE IF EXISTS `fc_group`;
CREATE TABLE fc_group (
    id bigint primary key auto_increment,
    name varchar(255) not null,
    course_id bigint not null,
    class_num tinyint not null,
    leader_id bigint not null,
    -- Status: norMal, Dismissed
    status enum('M', 'D') not null,
    foreign key(course_id) references `fc_course`(id),
    foreign key(leader_id) references `fc_user`(id)
) engine=MyISAM;

-- Group Attend Table
DROP TABLE IF EXISTS `fc_group_attend`;
CREATE TABLE fc_group_attend (
    stu_id bigint not null,
    group_id bigint not null,
    foreign key(stu_id) references `fc_user`(id),
    foreign key(group_id) references `fc_group`(id)
) engine=MyISAM;

-- 选课表
DROP TABLE IF EXISTS `fc_select`;
CREATE TABLE fc_select (
    id bigint primary key auto_increment,
    course_id bigint not null,
    stu_id bigint not null,
    class_num bigint not null,
    group_id bigint,
    foreign key(course_id) references `fc_course`(id),
    foreign key(stu_id) references `fc_user`(id),
    foreign key(group_id) references `fc_group`(id)
) engine=MyISAM;

-- 讨论课表
DROP TABLE IF EXISTS `fc_discuss`;
CREATE TABLE fc_discuss (
    id bigint primary key auto_increment,
    course_id bigint not null,
    topic varchar(255) not null,
    -- 次序号
    serial_num int,
    -- 报名开始、结束事件
    signin_start_time bigint not null,
    signin_end_time bigint not null,
    contents text,
    foreign key(course_id) references `fc_course`(id)
) engine=MyISAM;

-- 讨论课报名表
DROP TABLE IF EXISTS `fc_discuss_signin`;
CREATE TABLE fc_discuss_signin (
    id bigint primary key auto_increment,
    discuss_id bigint not null,
    group_id bigint not null,
    signin_time bigint not null,
    foreign key(discuss_id) references `fc_discuss`(id),
    foreign key(group_id) references `fc_group`(id)
) engine=MyISAM;

-- 讨论课展示材料表
DROP TABLE IF EXISTS `fc_discuss_material`;
CREATE TABLE fc_discuss_material (
    id bigint primary key auto_increment,
    discuss_signin_id bigint not null,
    upload_time bigint not null,
    file_name varchar(255),
    file_url text,
    foreign key(discuss_signin_id) references `fc_discuss_signin`(id)
) engine=MyISAM;

-- Test Data
INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('TC', '19720182203919', 'lihan', 'Han Li', 'han@han-li.cn', 'M');

INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('ST', '2010101010', 'mingqiu', 'Ming Qiu', 'mingqiu@xmu.edu.cn', 'F');

INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('ST', '2020202020', '123456', 'Qingqiang Wu', 'wuqq@xmu.edu.cn', 'N');

INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('ST', '2020204040', '8888', 'Hongji Wang', 'whj@xmu.edu.cn', 'M');

INSERT INTO fc_admin (username, password, status)
VALUES ('han', 'lihan', 'M');

insert into fc_course (name, description, weight_speak, weight_report, weight_ask, grouping_regulation_id, status) 
values('OOAD', 'QMQMQMQMQM I am QM', 20, 30, 40, null, 'M');

insert into fc_course (id, name, description, weight_speak, weight_report, weight_ask, grouping_regulation_id, status) 
values('JAVAEE', 'QMQMQMQMQM I am QM', 20, 30, 40, null, 'M');

insert into fc_select(course_id, stu_id, class_num, group_id) values(1, 2, 1, null);

insert into fc_discuss(course_id, topic, serial_num, signin_start_time, signin_end_time, contents) 
values(1, 'How to get GPA4', 1, 1606218857, 1606439560, 'heheda');

insert into fc_group(name, course_id, class_num, leader_id, status) 
values('I want 4.0', 1, 1, 4, 'M');

insert into fc_group_attend(stu_id, group_id) 
values(4, 1);

insert into fc_discuss_signin(discuss_id, group_id, signin_time)
values(1, 1, 111);