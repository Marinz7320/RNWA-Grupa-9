<?php

if(!extension_loaded("soap")){
  dl("php_soap.dll");
}


ini_set("soap.wsdl_cache_enabled","0");

$server = new SoapServer("BAMtoHRK.wsdl");


function cBTK($yourValue){
  return $yourValue * 3.86 . "HRK";
}

$server->AddFunction("cBTK");
$server->handle();
?>

