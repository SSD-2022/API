
import { Navigate, Outlet } from "react-router-dom";
import Auth from "./Auth";

const useAuth = () => {
  const user = { loggedIn: false };
  return user && user.loggedIn;
};

const x = Auth.isAuthenticated();

//This function checks if user is authenticated. If not, redirects to login page.
const ProtectedRoutes = () => {
  console.log("Route")
  console.log(x)
  return x ? <Outlet /> : <Navigate to="/Login" />;
};

export default ProtectedRoutes;