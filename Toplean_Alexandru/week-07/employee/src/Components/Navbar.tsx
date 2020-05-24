import { Navbar, Nav, NavItem, NavDropdown } from "react-bootstrap";
import React, { CSSProperties, useState } from "react";
import { Link, BrowserRouter, Switch, Route, NavLink } from "react-router-dom";

import { DarkMode } from "./DarkMode";

type ConnectionProps = {
  employeeIsConnected: boolean;
  setEmployeeConnection: any;
};

export const DrawNavbar = (props: ConnectionProps) => {
  return (
    <React.Fragment>
      <header>
        <Navbar bg="dark" expand="lg" variant="dark" style={{ color: "white" }}>
          <NavLink
            className="navbar-brand"
            to={props.employeeIsConnected ? "/viewOrders" : "/login"}
          >
            Order And Pay
          </NavLink>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="mr-auto">
              <NavLink className="nav-link" to="/createMenu">
                Create Menu
              </NavLink>

              <NavLink className="nav-link" to="/createMenuItem">
                Create Menu Item
              </NavLink>
              <NavLink className="nav-link" to="/viewOrders">
                View Orders
              </NavLink>
              {props.employeeIsConnected ? (
                <NavLink className="nav-link" to="/login">
                  Log Out
                </NavLink>
              ) : (
                <NavLink className="nav-link" to="/login">
                  Log In
                </NavLink>
              )}
            </Nav>

            <DarkMode />
          </Navbar.Collapse>
        </Navbar>
      </header>
    </React.Fragment>
  );
};
