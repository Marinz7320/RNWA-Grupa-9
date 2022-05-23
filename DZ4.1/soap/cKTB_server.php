<?php

if(!extension_loaded("soap")){
  dl("php_soap.dll");
}


ini_set("soap.wsdl_cache_enabled","0");

$server = new SoapServer("HRKtoBAM.wsdl");


function cKTB($yourValue){
  return $yourValue * 0.26 . " BAM";
}

$server->AddFunction("cKTB");
$server->handle();
?>

