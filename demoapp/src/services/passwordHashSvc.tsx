import bcrypt from 'bcryptjs';

export const encryptPassword = async(password:string) => {
    const saltRounds = 10;
    const salt = bcrypt.genSaltSync(saltRounds);
    const saltedPassword = bcrypt.hashSync(password,salt); 
    return saltedPassword;
}

export const verifyPassword=async(userPassword:string,hashedPassword:string)=>{
    const passwordMatch = await bcrypt.compare(userPassword,hashedPassword);
    console.log(passwordMatch);
    return passwordMatch;
}