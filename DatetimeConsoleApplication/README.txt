Application Name: Datetime Console Application
Developer: Ricardo G. Saraiva
CreatedAt: 22-04-2018;
Description: Datetime Console Application is based in a .NET Datetime Class.
Github: https://github.com/ricardogomessaraiva

==============================================================================================

Systemic Roles:
* Input datetime has to be these format - dd/MM/yyyy HH:mm (Brazilian format). 
  Otherwise will be Date or time invalid.

Important: The bissext year are do not validated;

Datetime Format types supported:
* type 1 -> dd/mm/yyyy hh:mm  - Output:  [01/01/2000 11:30]
* type 2 -> dd-mm-yyyy hh:mm  - Output:  [01-01-2000 11:30]
* type 3 -> dd/MES/yyyy hh:mm - Output:  [01/Janeiro/2000 11:30]
* type 4 -> dd de mm de yyyy, hh hora(s) e mm minuto(s) - Output: [01 de Janeiro de 2000, 11 hora(s) e 30 minuto(s)]