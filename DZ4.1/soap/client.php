<?php

header('Content-Type: text/plain');

try{
	ini_set('soap.wsdl_cache_enabled',0);
	ini_set('soap.wsdl_cache_ttl',0);

	$value = $_POST['value'];
	if($_POST['currency'] === "toEur"){
		$sClient = new SoapClient('toEur.wsdl');
		$response = $sClient->cBTE($value);
	}
	else if($_POST['currency'] === "toBam"){
		$sClient = new SoapClient('toBam.wsdl');
		$response = $sClient->cETB($value);
	}
	else if($_POST['currency'] === "HRKtoBam"){
		$sClient = new SoapClient('HRKtoBam.wsdl');
		$response = $sClient->cKTB($value);
	}
	else if($_POST['currency'] === "BAMtoHRK") {
		$sClient = new SoapClient('BAMtoHRK.wsdl');
		$response = $sClient->cBTK($value);
	}
	var_dump($response);

} catch(SoapFault $e){
  var_dump($e);
  echo $e;
}

?>