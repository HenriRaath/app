﻿using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(FrontController))]
  public class FrontControllerSpecs
  {
    public abstract class concern : Observes<IProcessRequests, 
                                      FrontController>
    {
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        command_registry = depends.on<IFindCommands>();

        command_that_can_process_request = fake.an<IProcessOneRequest>();
        request = fake.an<IContainRequestInformation>();

        command_registry.setup(x => x.get_command_that_can_process(request)).Return(command_that_can_process_request);
      };

      Because b = () =>
        sut.process(request);

      It should_delegate_the_processing_to_the_command_that_can_handle_the_request = () =>
        command_that_can_process_request.received(x => x.process(request));

      static IProcessOneRequest command_that_can_process_request;
      static IContainRequestInformation request;
      static IFindCommands command_registry;
    }
  }
}