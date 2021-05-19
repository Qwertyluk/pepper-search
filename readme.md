# PepperSearch program

This repository contains a source code of PepperSearch program.

## Overall information

* PepperSearch program was implemented to scrap data from www.pepper.pl page.
* The project is created using a UI framework called Windows Presentation Foundation (WPF).
* TimMeas gives the ability to search Pepper website in various ways without even visiting it.

## Functionality
* Displays scrapped discounts (title, link, current and previous price, percentage of discount, score, description)
* Gives the ability to scrap data by categories such as: Electronics, Gaming, Home, Fashion, Garden, Health, Family, Groceries, Motorization, Culture, Sport, Internet, Finance, Services, Travel
* User can scrap data with the inserted phrase.
* It is possible to find the inserted phrase in already scrapped data.
* User can determine how many pages should be scrapped.
* User can order each column by values at any time. The most useful seems to be sorting scrapped data by score or highest discount.

Application window:

<p align="center">
  <img src="https://i.ibb.co/3NWpBYP/pepper-Search-Main.png" alt="Main window">
</p>

Search feature - if the inserted phrase exists in the scrapped data, the column that contains such phrase is colored

<p align="center">
  <img src="https://i.ibb.co/kg74g1X/pepper-Search-Search-Feature.png" alt="Search feature">
</p>

It is possibility to scrap data only by category OR phrase.
By inserting the phrase into the text box next to the label called "Search in pepper", category selection becomes unavailable unless the text box is empty again.

<p align="center">
  <img src="https://i.ibb.co/BLyRRQn/pepper-Search-Scrap-Feature.png" alt="Chart window">
</p>


## Features that will be added in the future:

* The ability to start scrapping by pressing the Enter key.
* Displaying the progress bar that shows progress of the scrap process.