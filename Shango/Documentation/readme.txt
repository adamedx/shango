-------------------------------------------------------------------------------
Shango

Graphical Command Shell for .Net
-------------------------------------------------------------------------------


-------------------------------------------------------------------------------
Introduction
-------------------------------------------------------------------------------


What is Shango?

Shango is a line input command interpeter that can not only be used as a 
replacement for the default command interpeter utility of an operating system
(such as cmd.exe on the Windows NT platforms), but also creates new ways for humans
to interact with computers.  It does this chiefly by blurring the line between 
the Grahpical User Interface (GUI) that brought computers to the masses and
the command line interface that continues to survive among advanced users.


Key Features

1.  VBScript is the shell language
2.  Supports the concept of layered "meta-shells"
3.  Includes advanced utilities that allow browsing of the ole automation classes
    for a machine, as well as the .Net classes for the machine
4.  The command processor is extensible -- user enhancements can allow pre and post
    processing of commands
5.  Integrates with speech recognition and text to speech capabilities
6.  Extensible mechanism to display complex data files such as html and bitmaps
    inside the shell itself
7.  Extensible text editor built into the shell itself
8.  Task-switching inside the shell to reduce the need to start multiple shells
9.  Compatibility with ANSI terminal type for color rendering
10. Ability to save shell contents in rich text or html format
11. Ability to "name" to avoid starting new shell instances
12. Native remoting -- shells can be started remotely, and existing shells can 
    be shared among multiple clients
13. Advanced formatting options such as alpha-blended backgrounds, bitmap backgrounds,
    mixed fonts, multiple colors

build generates the following line sequences that we are not handling:

 0D 0D 0A
 

Next steps:
1. Make it useable with cmd
    a. Fix window buffer issue
2. Make it useable without cmd
    a. Duplicate builtin cmd commands
        i. dir
        ii. type
        iii. copy
        iv. echo
        v. md
        vi. rd
        vii. del
        viii. move
        ix. help        
    b. implement redirection
    c. Implement new grammar
    d. Implement disconnected processes
    e. fix doskey functionality
    f. implement batch file
    g. Implement state
        i. per thread options
        ii. global options
            A. title
            B. key bindings
            C. sounds
            D. pictures
            E. terminals
            F. command list
            G. prompt
            H. doskey features
    h. threads
3. Add new displays -- ttys
    a. html
    b. ansi.sys
    c. modify commands to leverage this
4. Add context support
    a. file
    b. registry
    c. ole automation
    d. .net
5. Add wscript support
6. add undo / redo support
7. remoting
8. advanced ui
    a. backgrounds
    b. transparency
    c. video
    d. visualizations
    e. text to speech
    f. speech recognition
    g. import
    h. fonts
    i. autoformat
9. Persistence
    a. xml
    b. style sheets
10. Preferences
11. Misc features
    a. Title bar
12. Reorganize namespaces / classes
13. Text Editor builtin command
    a. display of files
    b. keyboard mappings
    c. editing
    d. script editor
14. Macro recording
    
    
Notes:

The standard user interface will feature the following departures from the conventional command line interface:

1. In this user interface, each user input and user request is expressed as a standalone body of html text appended into the
html DOM of the user interface in temporal order.  This means that any valid html may be displayed in the user interface --
even controls and other elements may be added to the dom.
 
2. The redefinition of "command line" from a stream of text terminated by an end of line character to a stream of arbitrary data
that corresponds to a user request or a reply to a user request.  This change is analagous to the difference between lines
of a document and paragraphs in contemporary word processing software.  Such software aims the user focus at the paragraph, a 
unit of text which tends to share common formatting characteristics.  The intent of most command line interfaces is that one
command line corresponds to one user request or command.  Replies are often multi-line, but current command-line interfaces
do not group the multiple lines of the reply in any meaningful way.  The result is that after multiple commands are executed
in current command line interfaces, human parsing must be done to separate different commands from each other as well
as from user input which is often mixed in with the display of commands.

3. Separation of user input from tool output.  This actually has precedent in other user interfaces such as those for PDA's
which offer a separate "input area" that is only available when input is actually desired.  As implied above, the mixing of
user input and command output in the display forces more parsing on the user after multiple commands have been executed. The 
details of this separation are:
    a. Commands to be processed by the command processor may only be executed when entered in the input area of the interface
    b. Command output only appears in the output area
    c. Users may only interact with the output area in the following ways:
        i. They may read it :)
        ii. They may navigate to it and select text
        iii. They may interact with controls inserted into the output area according to the semantics of those controls

The key point to remember here is that commands may only come from the input area, but the output area may itself be interactive
due to the results of command output.

     
Interactive commands:

Most commands are not interactive -- they take a one time a priori input, and generate a posteriori output.  For such a non-interactive
command, The input and output have the following characteristics:
    1. No input is required from the user after the program starts
    2. The output is not dependent upon anything other than the input and the local state of the machine
        a. In particular, the output is not dependent on user input
    3. The termination of the program depends only on the initial input.

For an interactive command, the input and output have the following characteristics:
    1. Input is required of the user after the command is invoked      
    2. The output of the command may depend on input that occurs after the program has been invoked.
    3. Input may be requested multiple times during the execution of the program
    4. The termination of the program may depend on the user input that occurred after the program was invoked.

For interactive commands, we term the input and output that occur after invocation post-invocation i/o (PIIO).  In traditional
command shells, programs obtain access to PIIO through "standard input" and "standard output (error)" text streams.  Using text
streams for input and output makes a certain amount of sense for several reasons:

1. Input
    a. In most interactive commands, input arrives directly from humans.  When humans use command interfaces, the commands have
    a readily identifiable and consistent textual expression that is similar to the written text of human-to-human "natural" 
    communication.  Thus interactive commands are able to obtain direct communication from humans in a way that is convenient for
    humans to express.
    b. Text streams can easily be generated from human input devices, which means that input devices can use the text stream
    interface to interact with commands in real-time
    c. Text streams have an obvious and convenient persistent format (typically as files in a file system) such that sequences
    of input may be recorded in the persistent and replayed to commands through the text stream -- execution will proceed
    identically to that of the human input device case.
2. Ouptut
    a. Text streams can be easily transformed into human readable text communication, which means that commands can directly
    make requests of humans or present information in a way that humans can understand and potentially respond to with
    further user input.
    b. Text streams may be easily persisted as files in a file system, which means that useful output from a command such as a report
    on the state of the system can be saved and transmitted in various forms long after the command execution has completed, thus
    providing a long-lived record of the command.
3. Programmability
    a. Due to the symmetry of using text streams for both input and output, output text streams may also be used as input for
    subsequent commands, thus allowing for composition and chaining of commands to create more powerful sequences of commmands.
    
These strengths have allowed the text stream model of interactive command development to flourish to the present day.  However, the
utility, flexibility, and ease of composition have masked flaws which have limited the evolution of this model toward a
potentially more sophisticated composition model.  To understand this, we should first summarize some fundamental characteristics
of the text stream model:

1. All user input must be expressed as text
2. All user input must be converted from text to computationally useful runtime representations upon which the command can act.
3. All output must be converted from a runtime representation to a canonical text form readable to humans
4. If output such as the above is to be used as the interactive input to subsequent commands, extra command modes must be
implemented to add verbose information that allows exact deserialization of the output, since fully realized forms would often
be "noisy" and thus very difficult for humans to read.
5. All output used as input to other programs must be converted to text and then upon execution of the program using that output
as input, the input must be converted back from text to its original form.  There are two redundant text conversions in this process
6. Each command implements its own representation of input and output, so there is no consistent way from one command to another
to programatically interpret the input or output of another command
7. Due to the limitation above, global transformations that could act on all the input or output of commands cannot generally
be authored.
8. There is one other form of i/o in addition to interactive i/o and this do not use text streams as input and output:
    a. Procedural I/O: This i/o models the input and oiutput that a function in a procedural language utilizes:
        i.Command line arguments -- commands typically received this as in-memory individual argements at the start of execution
        ii.. Command results -- in traditional command systems, results are usually an integer number capable only of representing 
        simple results such as success or failure of the command.
    b. This additional form of i/o is separate from and incompatible with the interactive input and output text streams -- interoperation
    between these two forms of i/o is generally not possible without requiring substantial programming overhead and customized machinery 
    from the user.

Overall, the shortcomings of the text stream model can be summarized with the following sequence of statements:

1. In the legacy model, text streams serve as the canonical representation for input and output
2. Canonical representations should be generic, flexible, polymorphic, and transpoarent for maximum interoperability and composability,
and to support both human and artificial users
3. Text streams by themselves are not generic, flexible, or polymorphic in an efficient fashion and they are most
certainly not transparent.

To solve this, the following solution is proposed:

1. Replace the text stream representation with a canonical form that is generic, flexible, polymorphic, and transparent.
2. Use the same representation for all forms of input and output: interactive input and output as well as procedural
input and output

These capabilities will be utilized in the following fashion:

1. Transparency: because the i/o formats are transparent, generic filters for input or output
can be applied to any command to reformat output in arbitrary ways (e.g. textual vs. graphical presentations), or limit
results of a command to some range
2. Genericity: The canonical representation will allow constructs of any type with any amount of information to be
used as input our output -- commands are not limited to those things that can be efficiently represented textutally.
3. Polymorphism: the canonical representation will allow commands to take in multiple representations of the same information
such that callers do not need to be aware of the exact format of the data -- the representation will efficiently allow transformation
to related types by the command system or the commands themselves.
4. Flexibility: Due to the properties above and the uniform use of the representation for all forms of input and
output, users can compose commands with minimal or no knowledge of how the commands are connected or
implemented, and can be assured that the usefulness of a command is limited only by the semantics of its i/o, and
not the syntax.



