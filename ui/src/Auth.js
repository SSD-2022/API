//This method will authenticate users when used. 
//Will do the opposite as well.

class Auth {  
    constructor() {
      this.authenticated = true;
    }

    login() {
      this.authenticated = true;
      console.log("logged in"); 
      
    }
  
    logout() {
      this.authenticated = false;
      console.log("logged out");
      console.log(this.authenticated)
    }
  
    isAuthenticated() {
      console.log("Authe");
      return this.authenticated;
    }
  }
  
  export default new Auth();
  