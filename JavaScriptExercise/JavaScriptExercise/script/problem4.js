function truncate(input, maxlength){
    if (input.length <= maxlength) {
        console.log(input)
    } else {
        console.log(input.replace(input.substring(maxlength-1, input.length), '…'));
    }
    
}

truncate("hello world, welcome!", 5);