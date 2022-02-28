import React, { Component } from "react";
import "./Main.css";

export class Main extends Component {
  render() {
    const { children } = this.props;
    return <main className="main">{children}</main>;
  }
}
