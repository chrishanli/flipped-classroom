
-- 用户表 （学生、教师、管理员）
DROP TABLE IF EXISTS `fc_user`;
CREATE TABLE `fc_user` (
    id bigint primary key auto_increment,
    type enum('ST', 'TC', 'AD') not null,
    username varchar(50) not null,
    password varchar(50) not null,
    alias varchar(50) not null,
    email varchar(50),
    -- Status: New, norMal, Forbidden
    status enum('N', 'M', 'F') not null, 

    UNIQUE INDEX `idx_username_unique` (`username` ASC)
) engine=MyISAM;

-- 课程表
DROP TABLE IF EXISTS `fc_course`;
CREATE TABLE fc_course (
    id bigint primary key auto_increment,
    name varchar(255) not null,
    description varchar(255),
    weight_speak tinyint,
    weight_report tinyint,
    weight_ask tinyint,
    -- Status: norMal, Forbidden
    status enum('M', 'F') not null
) engine=MyISAM;

-- 选课表
DROP TABLE IF EXISTS `fc_select`;
CREATE TABLE fc_select (
    id bigint primary key auto_increment,
    course_id bigint not null,
    stu_id bigint not null,
    class_num bigint not null,
    foreign key(course_id) references `fc_course`(id),
    foreign key(stu_id) references `fc_user`(id)
) engine=MyISAM;

-- 讨论课表
DROP TABLE IF EXISTS `fc_discuss`;
CREATE TABLE fc_discuss (
    id bigint primary key auto_increment,
    course_id bigint not null,
    topic varchar(255) not null,
    -- 次序号
    serial_num int,
    -- 报名开始、结束时间
    attend_start datetime not null,
    attend_end datetime not null,
    contents text,
    foreign key(course_id) references `fc_course`(id)
) engine=MyISAM;

-- 讨论课报名表
DROP TABLE IF EXISTS `fc_discuss_attend`;
CREATE TABLE fc_discuss_attend (
    id bigint primary key auto_increment,
    discuss_id bigint not null,
    stu_id bigint not null,
    signin_time datetime not null DEFAULT CURRENT_TIMESTAMP,
    foreign key(discuss_id) references `fc_discuss`(id),
    foreign key(stu_id) references `fc_user`(id)
) engine=MyISAM;
ALTER TABLE `fc_discuss_attend` ADD UNIQUE INDEX(discuss_id, stu_id);

-- 讨论课展示材料表
DROP TABLE IF EXISTS `fc_discuss_material`;
CREATE TABLE fc_discuss_material (
    id bigint primary key auto_increment,
    attend_id bigint not null,
    upload_time datetime not null DEFAULT CURRENT_TIMESTAMP,
    file_name varchar(255),
    file_url varchar(255),
    type tinyint not null,
    foreign key(attend_id) references `fc_discuss_attend`(id)
) engine=MyISAM;

-- 讨论课展示提问表
DROP TABLE IF EXISTS `fc_discuss_question`;
CREATE TABLE fc_discuss_question (
    id bigint primary key auto_increment,
    attend_id bigint not null,
    question_time datetime not null,
    topic varchar(255),
    contents varchar(1023),
    foreign key(attend_id) references `fc_discuss_attend`(id)
) engine=MyISAM;

-- Test Data
INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('AD', 'a', 'a', 'LH爷爷', 'han@han-li.cn', 'M');

INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('ST', '243', '123456', '邱明', 'han@han-li.cn', 'N');

INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('ST', '197', 'han', 'Han Li', 'han@han-li.cn', 'M');

INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('TC', 't', 'han', 'LH爸爸', 'han@han-li.cn', 'M');

INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('ST', '2010101010', 'mingqiu', 'Ming Qiu', 'mingqiu@xmu.edu.cn', 'F');

INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('ST', '2020202020', '123456', 'Qingqiang Wu', 'wuqq@xmu.edu.cn', 'N');

INSERT INTO fc_user (type, username, password, alias, email, status)
VALUES ('ST', '2020204040', '8888', 'Hongji Wang', 'whj@xmu.edu.cn', 'M');

insert into fc_course (name, description, weight_speak, weight_report, weight_ask, status) 
values('OOAD', 'QMQMQMQMQM I am QM', 20, 30, 40, 'M');

insert into fc_course (name, description, weight_speak, weight_report, weight_ask, status) 
values('JAVAEE', 'QMQMQMQMQM I am QM', 20, 30, 40, 'M');

insert into fc_select(course_id, stu_id, class_num) values(1, 2, 1);

insert into fc_discuss(course_id, topic, serial_num, attend_start, attend_end, contents) 
values(1, 'How to get GPA4', 1, "2020-11-25T00:00:00", "2020-12-31T00:00:00", 'heheda');
