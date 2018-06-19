<?php
header("Content-Type:application/json");
if (!isset($_GET["token"]))
{
echo "Technical error";
exit();
}

if ($_GET["token"]!='Shalom123.')
{
echo "Invalid authorization";

exit();
}
//$con = mysqli_connect("us-cdbr-azure-southcentral-f.cloudapp.net","bed58acbb27ae3","ce0040ae","ecounties");
//if (!$con) 
//{
//die("Connection failed: " . mysqli_connect_error());
//}
//$con->set_charset("utf8");
//Put the json string that we received from Safaricom to an array


$data  = json_decode(file_get_contents('php://input'), true);
$transactiontype=  $data["TransactionType"];  
$transid= $data["TransID"];  
$transtime=  $data["TransTime"];  
$transamount= $data["TransAmount"]; 
$businessshortcode=  $data["BusinessShortCode"]; 
$billrefno=  $data["BillRefNumber"];  
$invoiceno=  $data["InvoiceNumber"];  
$msisdn=  $data["MSISDN"];  
$orgaccountbalance=   $data["OrgAccountBalance"];   
$firstname=$data["FirstName"];  
$middlename=$data["MiddleName"];  
$lastname=$data["LastName"];


$serverName = "tcp:ibc.database.windows.net,1433";
$connectionOptions = array(
    "Database" => "TopMarineProduction",
    "Uid" => "InsureGuest",
    "PWD" => "AzureCloud@2016"
);
//Establishes the connection
$conn = sqlsrv_connect($serverName, $connectionOptions);
if($conn === false)
{
    die(print_r(sqlsrv_errors(), true));
}
$sql="INSERT INTO mpesatransactions
( 
TransactionType,
TransID,
TransTime,
TransAmount,
BusinessShortCode,
BillRefNumber,
InvoiceNumber,
MSISDN,
FirstName,
MiddleName,
LastName,
OrgAccountBalance
)  
VALUES  
( 
'$transactiontype', 
'$transid', 
'$transtime', 
'$transamount', 
'$businessshortcode', 
'$billrefno', 
'$invoiceno', 
'$msisdn',
'$firstname', 
'$middlename', 
'$lastname', 
'$orgaccountbalance' 
)";
                        
$stmt=sqlsrv_query($conn, $sql);
//sqlsrv_close($connection);

if($stmt === false)
        {
            /*Handle the case of a duplicte e-mail address.*/
            $errors = sqlsrv_errors();
            if($errors[0]['code'] == 2601)
            {
                echo "Duplicate transactions detected</br>";
            }
            /*Die if other errors occurred.*/
            else
            {
                die(print_r($errors, true));
            }
        }
        else
        {
            echo '{"ResultCode":0,"ResultDesc":"Confirmation received successfully"}';
        }
        
//$sql="INSERT INTO mpesatransactions
//( 
//TransactionType,
//TransID,
//TransTime,
//TransAmount,
//BusinessShortCode,
//BillRefNumber,
//InvoiceNumber,
//MSISDN,
//FirstName,
//MiddleName,
//LastName,
//OrgAccountBalance
//)  
//VALUES  
//( 
//'$transactiontype', 
//'$transid', 
//'$transtime', 
//'$transamount', 
//'$businessshortcode', 
//'$billrefno', 
//'$invoiceno', 
//'$msisdn',
//'$firstname', 
//'$middlename', 
//'$lastname', 
//'$orgaccountbalance' 
//)";
 
//if (!mysqli_query($con,$sql)) 
 
//{ 
//echo mysqli_error($con); 
//} 
 
 
//else 
//{ 
//echo '{"ResultCode":0,"ResultDesc":"Confirmation received successfully"}';
//}
 
//mysqli_close($con); 

?>