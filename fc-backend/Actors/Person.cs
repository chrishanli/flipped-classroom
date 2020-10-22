﻿using System;
using System.Collections.Generic;
using System.Text;
using FCBackend.Dao;

namespace FCBackend.Actors
{
    abstract class Person
    {
        enum PersonStatus
        {
            NORMAL, FORBIDDEN
        }

        string username;
        string alias;
        string password;
        string phone;
        string email;
        PersonStatus status;

        public ulong Id { get; set; }

        public string Username
        {
            get { return username; }
            set
            {
                // TODO - validate
                username = value;
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                // TODO - validate
                password = value;
            }
        }

        public string Alias
        {
            get { return alias; }
            set
            {
                // TODO - validate
                alias = value;
            }
        }

        public string Phone
        {
            get { return phone; }
            set
            {
                // TODO - validate
                phone = value;
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                // TODO - validate
                email = value;
            }
        }

        protected Person(ulong id, string alias, string username, string password, string phone, string email)
        {
            Id = id;
            Username = username;
            Password = password;
            Phone = phone;
            Email = email;
        }

        public static bool ChangeInfoById(ulong id, string username, string phone, string email, string alias)
        {
            return PersonDao.ChangePersonInfo(id, username, email, phone, alias);
        }

        public static bool ChangePasswordById(ulong id, string password)
        {
            return PersonDao.ChangePersonPassword(id, password);
        }

        public static bool DeletePersonById(ulong id)
        {
            return PersonDao.DeletePerson(id);
        }
    }
}