# Epicodus Week 6 Day 5 Hair Salon

## Author(s)

  * Steven Colburn

## Date

07/13/2018

## Specifications

  * Connects to MySql database
  * Employee List all Stylist
  * Employee Adds Stylist
  * Employee adds customer to stylist
    * Customer requires Stylist first
  * Employee Select Stylist and see details including customer list
  * Html link between client and stylists
  * Remove Stylist (Single)
  * Remove Stylist (All)
  * Remove Client (Single)
  * Remove Client (All)
  * Add Sepcialty to Stylist
  * Add Stylist to Specialty
  * View All Specialties
  * View Specialty Details
  * Edit Client Details
  * Edit Stylist Name
  * View all stylists by specialty



## Run HairSalon

  * cd HairSalon.Solution
  * cd HairSalon
  * dotnet restore
  * dotnet build
  * dotnet run
  * open browser (Chrome)
  * Enter http://localhost:5000 as a url

## Test HairSalon

  * cd HairSalon.Solution
  * cd HairSalon.Tests
  * dotnet restore
  * dotnet build
  * dotnet test

## Database

  * CREATE DATABASE steven_colburn;
  * USE steven_colburn;

  * CREATE TABLE `steven_colburn`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;

  * CREATE TABLE `steven_colburn`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `stylistId` INT NOT NULL , `name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;

  * CREATE TABLE `steven_colburn`.`specialties` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

  * CREATE DATABASE steven_colburn_test;
  * USE steven_colburn_test;

  * CREATE TABLE `steven_colburn_test`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;

  * CREATE TABLE `steven_colburn_test`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `stylistId` INT NOT NULL , `name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;

  * CREATE TABLE `steven_colburn_test`.`specialties` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB;

## Requirements

  Here are the user stories that your app should already fulfill:

    [x] As a salon employee, I need to be able to see a list of all our stylists.
    [x] As an employee, I need to be able to select a stylist, see their details, and see a list of all clients that belong to that stylist.
    [x] As an employee, I need to add new stylists to our system when they are hired.
    [x] As an employee, I need to be able to add new clients to a specific stylist. I should not be able to add a client if no stylists have been added.

And here are the user stories that the salon owner would like you to add:

    [x] As an employee, I need to be able to delete stylists (all and single).
    [x] As an employee, I need to be able to delete clients (all and single).
    [x] As an employee, I need to be able to view clients (all and single).
    [x] As an employee, I need to be able to edit JUST the name of a stylist. (You can choose to allow employees to edit additional properties but it is not required.)
    [ ] As an employee, I need to be able to edit ALL of the information for a client.
    [x] As an employee, I need to be able to add a specialty and view all specialties that have been added.
    [ ] As an employee, I need to be able to add a specialty to a stylist.
    [ ] As an employee, I need to be able to click on a specialty and see all of the stylists that have that specialty.
    [ ] As an employee, I need to see the stylist's specialties on the stylist's details page.
    [ ] As an employee, I need to be able to add a stylist to a specialty.


## License

MIT License

Copyright (c) 2018 Steven Colburn

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
