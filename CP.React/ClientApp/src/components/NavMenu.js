import { useIsAuthenticated } from "@azure/msal-react";
import * as React from "react";
import { SignInButton } from "./authentication/SignInButton";
import { SignOutButton } from "./authentication/SignOutButton";

export default function NavMenu() {
  const isAuthenticated = useIsAuthenticated();

  return (
    <div className="container fixed-top" style={{ backgroundColor: "#F4F5FD" }}>
      <header className="d-flex flex-wrap align-items-center justify-content-center justify-content-md-between py-3 mb-4 border-bottom">
        <a
          href="/"
          className="d-flex align-items-center col-md-3 mb-2 mb-md-0 text-dark text-decoration-none"
        >
          CP
        </a>
        <ul className="nav col-12 col-md-auto mb-2 justify-content-center mb-md-0">
          <li>
            <a href="#" className="nav-link px-2 link-secondary">
              Home
            </a>
          </li>
          <li>
            <a href="#" className="nav-link px-2 link-dark">
              Features
            </a>
          </li>
          <li>
            <a href="#" className="nav-link px-2 link-dark">
              Pricing
            </a>
          </li>
          <li>
            <a href="#" className="nav-link px-2 link-dark">
              FAQs
            </a>
          </li>
          <li>
            <a href="#" className="nav-link px-2 link-dark">
              About
            </a>
          </li>
        </ul>
        <div className="col-md-3 text-end">
          {isAuthenticated ? <SignOutButton /> : <SignInButton />}
        </div>
      </header>
    </div>
  );
}
