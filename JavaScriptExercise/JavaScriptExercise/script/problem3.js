function checkEmailId(email) {
    if (email.includes('@') && email.includes('.')) {
        if (email.indexOf('@') < email.indexOf('.')) {
            if ((email.substring(email.indexOf('@')+1,email.indexOf('.'))).length>0){
                return true;
            } else {
                alert("Invaild Email Address: there must be some characters between '@' and '.'!");
                return false;
            }
        } else {
            alert("Invaild Email Address: '@' must come before '.'!");
            return false;
        }
    } else {
        alert("Invaild Email Address: missing '@' or '.' or both!");
        return false;
    }
   
}

var email = "zhshao@yahoo.com"
console.log(checkEmailId(email));