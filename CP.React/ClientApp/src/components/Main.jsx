import React, { Component } from "react";

export class Main extends Component {
  render() {
    const { children } = this.props;
    return <div className="container-fluid">{children}</div>;
  }
}
