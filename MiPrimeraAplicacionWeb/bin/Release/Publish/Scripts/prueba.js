document.write("Programa para determinar si un número es par:<br/>");
var num = parseInt(prompt("Proporciona un número", 1));
if (num >= 0) {
    if (num % 2 == 0) {
        document.write("SI es número par");
        document.write("<br><br><br>");
    }
    else {
        document.write("NO es número par");
    }
}
else {
    document.write("Proporcione un valor entero y mayor a cero");
}