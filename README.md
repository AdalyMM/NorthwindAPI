Puede ser probado desde el Swagger que genera la aplicación.

**/api/Orders/Extended** es la dirección que regresa el reporte de Orders.

En la tabla Products:

Para probar un **POST** (api/Products):
```
{
"productId": 78,
"productName": "Original Frankfurter grne Soe",
"supplierId": 12,
"categoryId": 2,
"quantityPerUnit": "12 boxes",
"unitPrice": 13,
"unitsInStock": 32,
"unitsOnOrder": 0,
"reorderLevel": 15,
"discontinued": 0,
"category": null,
"supplier": null
}
```
Para un **PUT** es el mismo.

En la tabla Regions:

Para probar un **POST** (api/Regions)
```
{
"regionId": 5,
"regionDescription": "Middle",
}
```
Para un **PUT** es el mismo.

El **DELETE** solo funciona en los elementos que creamos que no han sido referenciados con otras tablas.
