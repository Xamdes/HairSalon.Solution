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

  * CREATE DATABASE steven_colburn_test;
  * USE steven_colburn_test;

  * CREATE TABLE `steven_colburn_test`.`stylists` ( `id` INT NOT NULL AUTO_INCREMENT , `name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;

  * CREATE TABLE `steven_colburn_test`.`clients` ( `id` INT NOT NULL AUTO_INCREMENT , `stylistId` INT NOT NULL , `name` VARCHAR(255) CHARACTER SET utf8 COLLATE utf8_general_ci NOT NULL , PRIMARY KEY (`id`)) ENGINE = InnoDB CHARSET=utf8 COLLATE utf8_general_ci;

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
