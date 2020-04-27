# NCC-Placement-Assignment

- Main idea of the web app is revolved around medical conditions and getting quick access to the symptoms and treatment of a medical condition without being overloaded with other information.

- On the home page, a user can input a condition, press a button and receive information about the symptoms of the condition. Used modularised content for this from the NHS API, but due to the NHS API only having modularised 
content for the most popular 250 conditions, it only works on the most popular 250 conditions.

- Due to the recent COVID-19 outbreak, I decided to include a dedicated page for this condition alone which contains the symptoms and recommended treatment for this as well as the date that it was last modified. 

- A user account system exists where users can register an account and include a condition they may have with their account. Following on from this, users are able to email themselves the treatment information about that condition to the email they provided during registration. Email isn't automatically sent to the email address and is only created and can then be sent but this can be easily changed to automatically send it. 

- In order to make sure that the data is up to date and accurate, the web app requests the current version of the information from the API each time it is needed.

- The design of the web app is simple to make sure that it can be used by varying audiences, colour scheme is very similar as on the NHS website as it fits in with the content of the site whilst providing a good contrast
between the background and colour of the text which makes it very easy to read.

- Further considering usability, the web app pages with content contain buttons to increase the font size of the text to make it easier to see for people that find it hard to read.

- To prevent user error, validation exists for almost all of the user input fields within the 
