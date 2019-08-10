/*
Navicat MySQL Data Transfer

Source Server         : local
Source Server Version : 80013
Source Host           : localhost:3306
Source Database       : gogogo

Target Server Type    : MYSQL
Target Server Version : 80013
File Encoding         : 65001

Date: 2019-08-10 14:35:24
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `wx_uuid` varchar(225) DEFAULT NULL,
  `wx_name` varchar(255) DEFAULT NULL,
  `nick_name` varchar(255) NOT NULL,
  `real_name` varchar(255) DEFAULT NULL,
  `title` varchar(255) DEFAULT NULL,
  `pwd` varchar(255) NOT NULL,
  `work_groups` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `roles` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `employee_no` varchar(255) DEFAULT NULL,
  `mobile_no` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `is_banned` bit(1) DEFAULT b'0',
  `last_login_date` datetime DEFAULT NULL,
  `last_session_id` varchar(255) DEFAULT NULL,
  `last_login_ip` varchar(255) DEFAULT NULL,
  `created` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
