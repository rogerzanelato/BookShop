import React, { Component } from "react";
import { Route } from "react-router";
import Layout from "./pages/Layout";
import Books from "./pages/Books";
import BookForm from "./pages/Books/BookForm";

export default class App extends Component {
  static displayName = App.name;

  render() {
    return (
      <Layout>
        <Route exact path="/" component={Books} />
        <Route path="/book/form/:id?" component={BookForm} />
      </Layout>
    );
  }
}
