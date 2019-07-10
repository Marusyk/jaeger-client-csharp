/**
 * Autogenerated by Thrift Compiler (0.12.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Thrift;
using Thrift.Collections;


namespace Jaeger.Thrift.Agent.Zipkin
{
  public static class zipkincoreConstants
  {
    /// <summary>
    /// The client sent ("cs") a request to a server. There is only one send per
    /// span. For example, if there's a transport error, each attempt can be logged
    /// as a WIRE_SEND annotation.
    /// 
    /// If chunking is involved, each chunk could be logged as a separate
    /// CLIENT_SEND_FRAGMENT in the same span.
    /// 
    /// Annotation.host is not the server. It is the host which logged the send
    /// event, almost always the client. When logging CLIENT_SEND, instrumentation
    /// should also log the SERVER_ADDR.
    /// </summary>
    public const string CLIENT_SEND = "cs";
    /// <summary>
    /// The client received ("cr") a response from a server. There is only one
    /// receive per span. For example, if duplicate responses were received, each
    /// can be logged as a WIRE_RECV annotation.
    /// 
    /// If chunking is involved, each chunk could be logged as a separate
    /// CLIENT_RECV_FRAGMENT in the same span.
    /// 
    /// Annotation.host is not the server. It is the host which logged the receive
    /// event, almost always the client. The actual endpoint of the server is
    /// recorded separately as SERVER_ADDR when CLIENT_SEND is logged.
    /// </summary>
    public const string CLIENT_RECV = "cr";
    /// <summary>
    /// The server sent ("ss") a response to a client. There is only one response
    /// per span. If there's a transport error, each attempt can be logged as a
    /// WIRE_SEND annotation.
    /// 
    /// Typically, a trace ends with a server send, so the last timestamp of a trace
    /// is often the timestamp of the root span's server send.
    /// 
    /// If chunking is involved, each chunk could be logged as a separate
    /// SERVER_SEND_FRAGMENT in the same span.
    /// 
    /// Annotation.host is not the client. It is the host which logged the send
    /// event, almost always the server. The actual endpoint of the client is
    /// recorded separately as CLIENT_ADDR when SERVER_RECV is logged.
    /// </summary>
    public const string SERVER_SEND = "ss";
    /// <summary>
    /// The server received ("sr") a request from a client. There is only one
    /// request per span.  For example, if duplicate responses were received, each
    /// can be logged as a WIRE_RECV annotation.
    /// 
    /// Typically, a trace starts with a server receive, so the first timestamp of a
    /// trace is often the timestamp of the root span's server receive.
    /// 
    /// If chunking is involved, each chunk could be logged as a separate
    /// SERVER_RECV_FRAGMENT in the same span.
    /// 
    /// Annotation.host is not the client. It is the host which logged the receive
    /// event, almost always the server. When logging SERVER_RECV, instrumentation
    /// should also log the CLIENT_ADDR.
    /// </summary>
    public const string SERVER_RECV = "sr";
    /// <summary>
    /// Message send ("ms") is a request to send a message to a destination, usually
    /// a broker. This may be the only annotation in a messaging span. If WIRE_SEND
    /// exists in the same span, it follows this moment and clarifies delays sending
    /// the message, such as batching.
    /// 
    /// Unlike RPC annotations like CLIENT_SEND, messaging spans never share a span
    /// ID. For example, "ms" should always be the parent of "mr".
    /// 
    /// Annotation.host is not the destination, it is the host which logged the send
    /// event: the producer. When annotating MESSAGE_SEND, instrumentation should
    /// also tag the MESSAGE_ADDR.
    /// </summary>
    public const string MESSAGE_SEND = "ms";
    /// <summary>
    /// A consumer received ("mr") a message from a broker. This may be the only
    /// annotation in a messaging span. If WIRE_RECV exists in the same span, it
    /// precedes this moment and clarifies any local queuing delay.
    /// 
    /// Unlike RPC annotations like SERVER_RECV, messaging spans never share a span
    /// ID. For example, "mr" should always be a child of "ms" unless it is a root
    /// span.
    /// 
    /// Annotation.host is not the broker, it is the host which logged the receive
    /// event: the consumer.  When annotating MESSAGE_RECV, instrumentation should
    /// also tag the MESSAGE_ADDR.
    /// </summary>
    public const string MESSAGE_RECV = "mr";
    /// <summary>
    /// Optionally logs an attempt to send a message on the wire. Multiple wire send
    /// events could indicate network retries. A lag between client or server send
    /// and wire send might indicate queuing or processing delay.
    /// </summary>
    public const string WIRE_SEND = "ws";
    /// <summary>
    /// Optionally logs an attempt to receive a message from the wire. Multiple wire
    /// receive events could indicate network retries. A lag between wire receive
    /// and client or server receive might indicate queuing or processing delay.
    /// </summary>
    public const string WIRE_RECV = "wr";
    /// <summary>
    /// Optionally logs progress of a (CLIENT_SEND, WIRE_SEND). For example, this
    /// could be one chunk in a chunked request.
    /// </summary>
    public const string CLIENT_SEND_FRAGMENT = "csf";
    /// <summary>
    /// Optionally logs progress of a (CLIENT_RECV, WIRE_RECV). For example, this
    /// could be one chunk in a chunked response.
    /// </summary>
    public const string CLIENT_RECV_FRAGMENT = "crf";
    /// <summary>
    /// Optionally logs progress of a (SERVER_SEND, WIRE_SEND). For example, this
    /// could be one chunk in a chunked response.
    /// </summary>
    public const string SERVER_SEND_FRAGMENT = "ssf";
    /// <summary>
    /// Optionally logs progress of a (SERVER_RECV, WIRE_RECV). For example, this
    /// could be one chunk in a chunked request.
    /// </summary>
    public const string SERVER_RECV_FRAGMENT = "srf";
    /// <summary>
    /// The value of "lc" is the component or namespace of a local span.
    /// 
    /// BinaryAnnotation.host adds service context needed to support queries.
    /// 
    /// Local Component("lc") supports three key features: flagging, query by
    /// service and filtering Span.name by namespace.
    /// 
    /// While structurally the same, local spans are fundamentally different than
    /// RPC spans in how they should be interpreted. For example, zipkin v1 tools
    /// center on RPC latency and service graphs. Root local-spans are neither
    /// indicative of critical path RPC latency, nor have impact on the shape of a
    /// service graph. By flagging with "lc", tools can special-case local spans.
    /// 
    /// Zipkin v1 Spans are unqueryable unless they can be indexed by service name.
    /// The only path to a service name is by (Binary)?Annotation.host.serviceName.
    /// By logging "lc", a local span can be queried even if no other annotations
    /// are logged.
    /// 
    /// The value of "lc" is the namespace of Span.name. For example, it might be
    /// "finatra2", for a span named "bootstrap". "lc" allows you to resolves
    /// conflicts for the same Span.name, for example "finatra/bootstrap" vs
    /// "finch/bootstrap". Using local component, you'd search for spans named
    /// "bootstrap" where "lc=finch"
    /// </summary>
    public const string LOCAL_COMPONENT = "lc";
    /// <summary>
    /// Indicates a client address ("ca") in a span. Most likely, there's only one.
    /// Multiple addresses are possible when a client changes its ip or port within
    /// a span.
    /// </summary>
    public const string CLIENT_ADDR = "ca";
    /// <summary>
    /// Indicates a server address ("sa") in a span. Most likely, there's only one.
    /// Multiple addresses are possible when a client is redirected, or fails to a
    /// different server ip or port.
    /// </summary>
    public const string SERVER_ADDR = "sa";
    /// <summary>
    /// Indicates the remote address of a messaging span, usually the broker.
    /// </summary>
    public const string MESSAGE_ADDR = "ma";
  }
}
